<template>
  <div class="pattern-tracking">
    <div class="page-header">
      <h2>Pattern Tracking</h2>
      <div class="search-section">
        <label for="pattern-search">Pattern Number or Description:</label>
        <div class="search-input-group">
          <input 
            type="text" 
            id="pattern-search" 
            placeholder="Pattern Number"
            v-model="searchQuery"
          >
          <button class="find-btn" @click="searchPatterns">Find</button>
        </div>
      </div>
    </div>

    <div class="table-container">
      <table class="data-table">
        <thead>
          <tr>
            <th>Pattern</th>
            <th>Copy</th>
            <th>Index</th>
            <th>Description</th>
            <th>Status</th>
            <th>Current Locations</th>
          </tr>
        </thead>
        <tbody>
          <tr 
            v-for="pattern in currentPageData" 
            :key="pattern.id"
            class="table-row"
            @click="goToPatternDetail(pattern.id)"
          >
            <td>{{ pattern.pattern }}</td>
            <td>{{ pattern.copy }}</td>
            <td>{{ pattern.index }}</td>
            <td>{{ pattern.description }}</td>
            <td>{{ pattern.status }}</td>
            <td>{{ pattern.location }}</td>
          </tr>
        </tbody>
      </table>
    </div>

    <div class="pagination-container">
      <div class="pagination-controls">
        <button class="pagination-btn" @click="goToFirstPage" :disabled="currentPage === 1">
          <span>&laquo;&laquo;</span>
        </button>
        <button class="pagination-btn" @click="goToPreviousPage" :disabled="currentPage === 1">
          <span>&laquo;</span>
        </button>
        
        <div class="page-numbers">
          <button 
            v-for="page in visiblePages" 
            :key="page"
            class="page-number"
            :class="{ active: page === currentPage }"
            @click="goToPage(page)"
          >
            {{ page }}
          </button>
          <span v-if="showEllipsis" class="ellipsis">...</span>
        </div>
        
        <button class="pagination-btn" @click="goToNextPage" :disabled="currentPage === totalPages">
          <span>&raquo;</span>
        </button>
        <button class="pagination-btn" @click="goToLastPage" :disabled="currentPage === totalPages">
          <span>&raquo;&raquo;</span>
        </button>
      </div>
      
      <div class="pagination-info">
        <label for="page-size">Page size:</label>
        <select id="page-size" v-model="pageSize" @change="onPageSizeChange">
          <option value="10">10</option>
          <option value="25">25</option>
          <option value="50">50</option>
          <option value="100">100</option>
        </select>
        <span class="item-count">{{ totalItems }} items in {{ totalPages }} pages</span>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'PatternTrackingView',
  data() {
    return {
      searchQuery: '',
      currentPage: 1,
      pageSize: 10,
      patterns: [
        { id: 1, pattern: '00107', copy: '1', index: '', description: 'SAND CAP 10L/M/H', status: 'Undetermined', location: '1 - 1' },
        { id: 2, pattern: '0X20J3B', copy: '1', index: '00', description: 'HEAVY BOLLARD CSB-9', status: 'Undetermined', location: 'Unknown' },
        { id: 3, pattern: '0X20J3C', copy: '1', index: '', description: 'IMP J 14X10X20', status: 'Undetermined', location: 'Ruhrpumpen Monterrey - BODEGA RP 206-C 2-NOV-12' },
        { id: 4, pattern: '0X20J3D', copy: '1', index: '', description: '', status: 'Undetermined', location: 'Unknown' },
        { id: 5, pattern: '0X20J3E', copy: '1', index: '', description: '', status: 'Undetermined', location: 'Unknown' },
        { id: 6, pattern: '0X20J3F', copy: '1', index: '', description: '', status: 'Undetermined', location: 'Unknown' },
        { id: 7, pattern: '0X20J3G', copy: '1', index: '', description: '', status: 'Undetermined', location: 'Unknown' },
        { id: 8, pattern: '0X20J3H', copy: '1', index: '', description: '', status: 'Undetermined', location: 'Unknown' },
        { id: 9, pattern: '0X20J3I', copy: '1', index: '', description: '', status: 'Undetermined', location: 'Unknown' },
        { id: 10, pattern: '0X20J3J', copy: '1', index: '', description: '', status: 'Undetermined', location: 'Unknown' }
      ],
      filteredPatterns: []
    }
  },
  computed: {
    totalItems() {
      return this.filteredPatterns.length;
    },
    totalPages() {
      return Math.ceil(this.totalItems / this.pageSize);
    },
    currentPageData() {
      const start = (this.currentPage - 1) * this.pageSize;
      const end = start + this.pageSize;
      return this.filteredPatterns.slice(start, end);
    },
    visiblePages() {
      const pages = [];
      const maxVisible = 10;
      let start = Math.max(1, this.currentPage - Math.floor(maxVisible / 2));
      let end = Math.min(this.totalPages, start + maxVisible - 1);
      
      if (end - start + 1 < maxVisible) {
        start = Math.max(1, end - maxVisible + 1);
      }
      
      for (let i = start; i <= end; i++) {
        pages.push(i);
      }
      return pages;
    },
    showEllipsis() {
      return this.totalPages > 10;
    }
  },
  methods: {
    searchPatterns() {
      if (!this.searchQuery.trim()) {
        this.filteredPatterns = [...this.patterns];
      } else {
        this.filteredPatterns = this.patterns.filter(pattern => 
          pattern.pattern.toLowerCase().includes(this.searchQuery.toLowerCase()) ||
          pattern.description.toLowerCase().includes(this.searchQuery.toLowerCase())
        );
      }
      this.currentPage = 1;
    },
    goToPage(page) {
      this.currentPage = page;
    },
    goToFirstPage() {
      this.currentPage = 1;
    },
    goToPreviousPage() {
      if (this.currentPage > 1) {
        this.currentPage--;
      }
    },
    goToNextPage() {
      if (this.currentPage < this.totalPages) {
        this.currentPage++;
      }
    },
    goToLastPage() {
      this.currentPage = this.totalPages;
    },
    onPageSizeChange() {
      this.currentPage = 1;
    },
    goToPatternDetail(patternId) {
      this.$router.push(`/pattern/${patternId}`);
    }
  },
  mounted() {
    this.filteredPatterns = [...this.patterns];
  }
}
</script>

<style scoped>
.pattern-tracking {
  max-width: 1200px;
  margin: 0 auto;
  background: white;
  border-radius: 8px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
  overflow: hidden;
}

.page-header {
  background: white;
  padding: 20px;
  border-bottom: 1px solid #e5e7eb;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.page-header h2 {
  color: #1e40af;
  font-size: 24px;
  font-weight: bold;
  margin: 0;
}

.search-section {
  display: flex;
  align-items: center;
  gap: 10px;
}

.search-section label {
  font-weight: 500;
  color: #374151;
  white-space: nowrap;
}

.search-input-group {
  display: flex;
  align-items: center;
}

.search-input-group input {
  padding: 8px 12px;
  border: 1px solid #d1d5db;
  border-radius: 4px 0 0 4px;
  font-size: 14px;
  min-width: 200px;
}

.find-btn {
  padding: 8px 16px;
  background: #2563eb;
  color: white;
  border: none;
  border-radius: 0 4px 4px 0;
  cursor: pointer;
  font-weight: 500;
  transition: background-color 0.3s;
}

.find-btn:hover {
  background: #1d4ed8;
}

.table-container {
  overflow-x: auto;
}

.data-table {
  width: 100%;
  border-collapse: collapse;
  background: white;
}

.data-table th {
  background: #f3f4f6;
  padding: 12px 8px;
  text-align: left;
  font-weight: 600;
  color: #374151;
  border-bottom: 2px solid #e5e7eb;
  font-size: 14px;
}

.data-table td {
  padding: 10px 8px;
  border-bottom: 1px solid #f3f4f6;
  font-size: 14px;
  color: #374151;
}

.data-table tbody tr:hover {
  background: #f9fafb;
}

.table-row {
  cursor: pointer;
  transition: background-color 0.2s;
}

.table-row:hover {
  background: #e0f2fe !important;
}

.pagination-container {
  background: white;
  padding: 20px;
  border-top: 1px solid #e5e7eb;
  display: flex;
  justify-content: space-between;
  align-items: center;
  flex-wrap: wrap;
  gap: 20px;
}

.pagination-controls {
  display: flex;
  align-items: center;
  gap: 5px;
}

.pagination-btn {
  padding: 8px 12px;
  background: white;
  border: 1px solid #d1d5db;
  cursor: pointer;
  border-radius: 4px;
  transition: all 0.3s;
  font-size: 14px;
}

.pagination-btn:hover:not(:disabled) {
  background: #f3f4f6;
  border-color: #9ca3af;
}

.pagination-btn:disabled {
  opacity: 0.5;
  cursor: not-allowed;
}

.page-numbers {
  display: flex;
  align-items: center;
  gap: 2px;
}

.page-number {
  padding: 8px 12px;
  background: white;
  border: 1px solid #d1d5db;
  cursor: pointer;
  border-radius: 4px;
  transition: all 0.3s;
  font-size: 14px;
  min-width: 40px;
}

.page-number:hover {
  background: #f3f4f6;
  border-color: #9ca3af;
}

.page-number.active {
  background: #2563eb;
  color: white;
  border-color: #2563eb;
}

.ellipsis {
  padding: 8px 4px;
  color: #6b7280;
}

.pagination-info {
  display: flex;
  align-items: center;
  gap: 10px;
  font-size: 14px;
}

.pagination-info label {
  color: #374151;
  font-weight: 500;
}

.pagination-info select {
  padding: 6px 8px;
  border: 1px solid #d1d5db;
  border-radius: 4px;
  background: white;
}

.item-count {
  color: #6b7280;
  white-space: nowrap;
}

@media (max-width: 768px) {
  .page-header {
    flex-direction: column;
    align-items: flex-start;
    gap: 15px;
  }
  
  .search-section {
    width: 100%;
    flex-direction: column;
    align-items: flex-start;
  }
  
  .search-input-group {
    width: 100%;
  }
  
  .search-input-group input {
    flex: 1;
    min-width: auto;
  }
  
  .pagination-container {
    flex-direction: column;
    align-items: flex-start;
  }
  
  .pagination-controls {
    width: 100%;
    justify-content: center;
  }
  
  .page-numbers {
    flex-wrap: wrap;
    justify-content: center;
  }
}
</style> 